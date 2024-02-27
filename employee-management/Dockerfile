FROM node:8.9.4

WORKDIR /app

COPY package.json package-lock.json /app/

RUN npm install

# Install Angular CLI globally
RUN npm install -g @angular/cli@7.0.7

COPY . /app/

CMD ["ng", "serve", "--host", "0.0.0.0"]