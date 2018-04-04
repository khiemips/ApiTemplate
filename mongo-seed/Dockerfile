FROM mongo

COPY CustomerArea.json /CustomerArea.json
CMD mongoimport --host mongodb --db customerarea --collection Material --type json --file /CustomerArea.json --jsonArray