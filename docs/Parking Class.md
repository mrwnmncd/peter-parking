# Parking Space

A class that creates a *parking space* with an initial value defined in the variable class.

### Create a parking space
Create an instance of a parking space with `class ParkingSpace`. The constructor function take an integer as an argument for the number of parking lots created an run time.
```cs
ParkingSpace parking = new ParkingSpace();
```

When instanciated, it checks for a file `parking-space.txt` relative to where the executable is located (see file structure). It reads the file and counts the number of lines in it as it corresponds to the number of parking lots available. It also parses the pipe-separated data into a `Vehicle` object.

#### Instance Methods

* `public` `void` **`ParkVehicle`** <br />
    parameters: class **`Vehicle`** (can be `null`) <br />
    returns: **`void`** <br />
    If the parameter is null, `UserInterface.InputVehicle()` is invoked for console to prompt and input vehicle data (make, model, plate number) and a preferred parking lot is asked. It checks the availability of the parking lot and prompts to the console accordingly. <br />
    If the choice of parking lot is taken, it calls the `SearchNearestFreeParking()` method to search for the nearest available slot and recurse through it with the available slot if the user allows. <br /><br />
    `VehicleFS.CheckIfParkingLotIsAvailable()` is then called to read through the file and see if the line is empty, if so, the vehicle data is parsed as a pipe-separated string and is written into the file. Otherwise it prompts to the console that the parking is already taken and calls the `SearchNearestFreeParking()` method and asks the user then recurse through it if allowed.

* `public` `void` **`RemoveVehicle`** <br />
    parameters: *none* <br />
    returns: **void** <br />
    Once invoked, it asks the for console user input directly to enter a plate number and validate it directly. With the plate number as a paramater, the `SearchVehicle()` class method is invoked. If the method returns a null, the This very method also returns. Otherwise, it checks which line the plate number is located in the file and removes it by calling `VehicleFS.RemoveFromFile()` and passing the same plate number as an argument. It then prompts to the console that the vehicle of the plate number has been removed and the parking lot cleared. <br />

* public void `UpdateParkingDetails` <br />
    parameters: *none* <br />
    returns: **void** <br />
    Once invoked, this method calls the `UserInterface.InputPlateNumber()` to require an input for plate number from the user through the console. The method returns a string of the plate number asked and passed as an argument to `SearchVehicle()` class method. If the method returns a `null`, this method returns as well. Otherwise, 