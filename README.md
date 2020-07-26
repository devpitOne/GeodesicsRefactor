# GeodesicsRefactor

#A refactor of the provided solution to apply SOLID principles and design patterns, with a focus on Domain Driven Design. 

#Main refactors:
#Implementation of a Strategy Pattern for handling different distance calculation methods
#Interfacing of main library classes to allow easier mocking, injection in accordance with Dependency Inversion
#Inversion of Control for the Distance Controller and Strategy/Calculators
#Extraction of most of the controller methods to more appropriate locations like numeric extensions
#Validation on the controller method moved to its parameters, Swagger is really good at picking these up!
#Some variable renaming

#The Tests project has been extended to give some better code and case coverage. The OpenCover dependencies are not included but can be used.

Have fun!
