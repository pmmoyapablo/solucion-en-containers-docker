#FROM node:16.14.0 AS build-env

#WORKDIR /app

# Instalar las dependencias del proyecto
#COPY src/Frontend/BlueBank.Banca-FE/package.json ./package.json
#COPY src/Frontend/BlueBank.Banca-FE/package-lock.json ./package-lock.json

#RUN npm install

# Copiar los archivos del proyecto
#COPY . ./

# Construir el proyecto de Angular
#RUN npm run build

#Imagen final de docker que se utilizará en el despliegue
FROM nginx:1.13.9-alpine
#Use a volume is mor efficient and speed that filesystem
VOLUME /tmp
#Borro los ficheron por default en la ruta del Apache Nginx
RUN rm -rf /usr/share/nginx/html/*

#Copio la salida del proyecto en la ruta del Apache Nginx
COPY src/Frontend/BlueBank.Banca-FE/dist/ /usr/share/nginx/html
COPY test/BlueBank.Banca.Pruebas/coveragereport/ /usr/share/nginx/html/coveragereport

# Copiar la configuración de nginx dentro del contenedor
COPY src/Frontend/BlueBank.Banca-FE/nginx.conf /etc/nginx/conf.d/default.conf

CMD ["nginx", "-g", "daemon off;"]
