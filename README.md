# Weather Monitor

The Weather Monitor solution consists of five projects and follows Clean Architecture principles:

1. **WeatherMonitor.Domain** - Domain Layer
2. **WeatherMonitor.Infrastructure** - Infrastructure Layer
3. **WeatherMonitor.Application** - Application Layer
4. **WeatherMonitorWebAPI** - Presentation Layer
5. **WeatherMonitor** - Console-based client application

## Domain Layer
The domain layer has all the domain-specific functionalities, such as average temperature calculation and a data-point filter function.

## Infrastructure Layer
This layer has all the external factors, such as the BOM API client and related entities.

## Application Layer
This layer serves as a connector, facilitating communication between the domain and infrastructure layers. It exposes functionalities to the presentation layer.

## Presentation Layer
This is a Web API application that exposes some functionalities using minimal APIs. It has a global exception handling middleware and maintains a consistent JSON-based response structure. 

## Client Application
This is being built using TUI (Terminal UI v2). It gives more features to the end users. 
The users can use the mouse for navigation and can utilize the mouse scroll or Page-Up/Page-Down keys to scroll the table. 

Please go full screen for the best view.
 
1. To change the station, hit [F4] or click the button at the top. 
   Then, in the next screen, click on a station name.

2. To select a data point, hit [F6] or click the button at the top. 
   Then, in the next screen, click on a data point.

3. Hit [F5] or click on the Refresh button to reset the view to the default station.
 
4. The average temperature for the selected station will be displayed on the status bar at the bottom. 
   There are a bunch of other details as well.


