FROM grafana/grafana:latest

# copy configuration
COPY ./grafana.ini /etc/grafana

# provision
COPY ./provisioning/dashboard.yaml /etc/grafana/provisioning/dashboards
COPY ./provisioning/datasource.yaml /etc/grafana/provisioning/datasources