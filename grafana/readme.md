
### Grafana
https://grafana.com/docs/grafana/latest/installation/configure-docker/

#### Configuration
`grafana.ini` file overrides default configuration.

#### Data
data folder is where grafana keeps data and is mapped to current data folder.

#### InfluxDb as Data Source
Datasources are taken from `/etc/grafana/provisioning/datasources`

#### Also..
I need to understand how grafana works to make persistent other required files/folders.
There is a `provisioning` folder that I believe needs to be pre-populated?
