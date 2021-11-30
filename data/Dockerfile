FROM python:3.9-slim
WORKDIR /seeder

COPY . .

RUN python -m pip install -r ./requirements.txt
RUN apt-get update && \
    apt-get install -y postgresql-client

CMD ["bash", "./entry.sh"]

