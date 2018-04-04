pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        //cleanWs deleteDirs: true
        //git url: 'https://github.com/khiemips/ApiTemplate.git', branch: 'master'  
        sh "dotnet build ${APP_NAME}"
      }
    }
    stage('Package') {
      steps {
        sh """       
            docker build -t ${APP_NAME.toLowerCase()} . -f ${APP_NAME}/Dockerfile    
            docker login ${ACR_LOGINSERVER} -u ${ACR_USR} -p ${ACR_PSW}
            docker tag ${APP_NAME.toLowerCase()} ${ACR_IMAGE_URL}
            docker push ${ACR_IMAGE_URL}"""
      }
    }
    stage('Deploy') {
      steps {
        script {
          def appYaml = readYaml text: """apiVersion: extensions/v1beta1
kind: Deployment
metadata:
  name: ${APP_NAME.toLowerCase()}-deployment
spec:
  replicas: 1
  template:
    metadata:
      labels:
        app: ${APP_NAME.toLowerCase()}
    spec:
      containers:
      - name: ${APP_NAME.toLowerCase()}
        image: ${ACR_IMAGE_URL}
        ports:
        - containerPort: 80"""
        
        def svcYaml = readYaml text: """apiVersion: v1
kind: Service
metadata:
  name: ${APP_NAME.toLowerCase()}-service
spec:
  type: LoadBalancer
  ports:
  - port: 80
  selector:
    app: ${APP_NAME.toLowerCase()}"""
        
          writeYaml file: APP_YAML, data: appYaml
          writeYaml file: SVC_YAML, data: svcYaml
      }
      acsDeploy(azureCredentialsId: 'f97c9003-0d2e-4ae0-ba49-a928bdd1a6a0', 
                  resourceGroupName: 'ufab-microservices', 
                  containerService: 'ufabTestAKS | AKS', 
                  configFilePaths: "${APP_YAML}, ${SVC_YAML}", 
                  sshCredentialsId: 'aks-ssh')
      }
    }
  }
  environment {
    ACR_ID = credentials('acr-credentials')
    ACR_USR = "${env.ACR_ID_USR}"
    ACR_PSW = "${env.ACR_ID_PSW}"
    ACR_IMAGE_URL = "${ACR_LOGINSERVER}/${APP_NAME.toLowerCase()}:${BUILD_NUMBER}"
    APP_YAML = "app.yaml"
    SVC_YAML = "svc.yaml"

    APP_NAME = "ApiTemplate"
    }
}