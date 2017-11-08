# WinterIsComing

Inspired by "AnApiOfIceAndFire" This is an API which stores its Data in a Graph Database and enables you to query the World of Ice and Fire, aka Game of Thrones

Many thanks to https://github.com/joakimskoog/AnApiOfIceAndFire for providing inspiration and source data.


## Requirements

- Microsoft Visual Studio 2017
- .Net 4.6.1
- Neo4J Community Edition
- Vagrant (to use optional Vagrant Box with Neo4J Provisioned)

## Vagrant

A vagrant box is available in the "vagrant" folder. To use this box you will require vagrant-vbguest from [https://github.com/dotless-de/vagrant-vbguest](https://github.com/dotless-de/vagrant-vbguest). To provision this box just type "vagrant up" from within this folder. This installs Neo4J and setups up the database.
