# **Swapi-Backend**
The is the middleware for consuming the Star Wars API and serving the necessary data to the associated front-end application ([swapi-project](https://github.com/blue-acer/swapi-project)), when called.

The application was developed with Visual Studio 2022 with net6.0 framework.

For now, there is no testing in place for this project.

This application should be running before serving the front-end project, as it provides the necessary character names for populating the table.

Note:

Some of the groundwork has been started for adding further features:

- Client classes for the different SWAPI resources e.g., VehicleClient.cs, PlanetClient.cs, etc.
- Object classes for parsing data from the different SWAPI resources e.g, SpeciesDto.cs
- The project also needs further development with regards to performance.
