FROM node:17.1
WORKDIR /app
ARG URL_BASE="http://api:5000"

COPY . .

RUN apt-get update && apt-get install -y jq
RUN jq '.proxy="'${URL_BASE}'"' package.json > tmp.json && cat tmp.json > package.json

RUN npm install
# add `/app/node_modules/.bin` to $PATH
ENV PATH /app/node_modules/.bin:$PATH
ENV HOST=0.0.0.0

CMD ["npm", "run", "start"]