Vagrant.configure("2") do |config|
  config.vm.box = "ubuntu/bionic64"
  config.vm.synced_folder "./", "/vagrant"
  config.vm.network "forwarded_port", guest: 8080, host: 8080 # nginx port
  config.vm.network "forwarded_port", guest: 8080, host: 9090 # nginx port
  config.vm.network "forwarded_port", guest: 1880, host: 1880 # nodered port
  config.vm.network "forwarded_port", guest: 3000, host: 3000 # grafana port
  config.vm.provision :shell, path: "vagrant_provision.sh"
  
  config.vm.provider "virtualbox" do |vb|
    vb.name = "ShirkaDomotics"     
    vb.memory = 2048
    # vb.gui = true
  end
end
