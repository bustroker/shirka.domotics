echo "provisioning VM..."
sudo apt update
sudo apt-get update

# install docker and run
sudo apt -y install docker.io
sudo systemctl start docker
sudo systemctl enable docker
docker --version
echo "docker installed and running..."

# create group 'docker' and add user 'vagrant' (the one I connect with) to it
sudo groupadd docker
sudo usermod -aG docker vagrant
echo "docker group created and 'vagrant' user added to it..."

# install docker compose
sudo curl -L https://github.com/docker/compose/releases/download/1.26.2/docker-compose-`uname -s`-`uname -m` -o /usr/local/bin/docker-compose
sudo chmod +x /usr/local/bin/docker-compose
docker-compose --version
echo "docker compose installed..."

# install mosquitto client
sudo apt install -y mosquitto-clients

# install dotnet
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y apt-transport-https
sudo apt-get update
sudo apt-get install -y dotnet-sdk-3.1
dotnet --version
echo "dotnet 3.1 installed"

# install node and npm
sudo apt install -y nodejs npm

echo "done provisioning VM."

