pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        sh 'dotnet build ApiTemplate/ApiTemplate.csproj'
      }
    }
    stage('Package') {
      steps {
        sh """       
            docker build -t ${APP_TAG} . -f Deployment/ApiTemplate.develop.Dockerfile    
            docker login ${ACR_LOGINSERVER} -u ${ACR_USR} -p ${ACR_PSW}
            docker tag ${APP_TAG} ${ACR_IMAGE_URL}
            docker push ${ACR_IMAGE_URL}"""
      }
    }
    stage('Deploy') {
      steps {
        script{
          def fileName = "${env.WORKSPACE}/${APP_YAML}"
          def image = "${ACR_IMAGE_URL}"
          def yaml = readYaml file: fileName
          yaml.spec.template.spec.containers[0].image = image
          sh ('sudo rm -f ' + fileName)
          writeYaml file: fileName, data: yaml
        }

        acsDeploy(azureCredentialsId: 'f97c9003-0d2e-4ae0-ba49-a928bdd1a6a0', 
                  resourceGroupName: 'ufab-microservices', 
                  containerService: 'ufabTestAKS | AKS', 
                  configFilePaths: "${APP_YAML}, ${APP_SVC_YAML}", 
                  sshCredentialsId: 'aks-ssh')
      }
    }
  }
  post {
    always {
        echo('Testing unimplemented')
    }
  }
  environment {
    ACR_ID = credentials('acr-credentials')
    ACR_USR = "${env.ACR_ID_USR}"
    ACR_PSW = "${env.ACR_ID_PSW}"
    APP_TAG = "apitemplate"
    APP_YAML = "Deployment/ApiTemplate-App.develop.yaml"
    APP_SVC_YAML = "Deployment/ApiTemplate-Svc.develop.yaml"
    ACR_IMAGE_URL = "${ACR_LOGINSERVER}/${APP_TAG}:${BUILD_NUMBER}"
  }
}