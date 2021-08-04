![DroneTrafficFlow](/DRONE.png)
# 🗜 Simulating Drone Delivery
The Library makes use of vector calculations to simulate drone traffic flow in an airspace. The simulation is coded in F# and makes use of no external libraries.
[Download Fsharp](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/install-fsharp
)

# Documentation
The library utilizes a type of vec, different prefixed start positions for easier unit testing.

A vector type is created as a tuple of:
```float*float```

which we later utilize for vector calculations.

We thereafter define different operators for vector calculations: ```+@``` for scaling vectors with a float, ```+|``` for addition of two vectors and lastly ```+-``` for subtraction of two vectors.

We also write two functions to calculate the vectorLength with the use of pythagoras, including normalizing the vector with the appropriate length calculated. This is to ensure that it travels with the appropriate speed given in the Drone property speed.
## ✈️ Drone Class
The Drone's constructor is built with the properties: 
1. vector: startpos
2. vector: dest
3. float: speed
4. string: UUID

Let's build two new Drones, start by creating a new .fsx file (example.fsx):


```let packageOne = new Drone((10., 5.), (origin), 1., "Package: New Computer Mouse!")```

```let packageTwo = new Drone((2., 0.), (origin), 2., "Package: A 50 inch Smart-TV")```

### getSpeed()
Returns the Drone's speed.
#### Usage
To get the Drone's speed, we write:

```packageOne.getSpeed()```

which returns a speed of 1. in our example.
### isFinished()
Returns a boolean based on if the Drone has reached its destination.
#### Usage
To check if the Drone has reached it's destination, we write:

```packageOne.isFinished()```

 in our example it returns 

### setFinished()
Updates the boolean of isFinished() to true.
#### Usage
To confirm the Drone has reached its position we write:

```packageOne.setFinished()```
### Fly()
Moves the Drone to a newPosition based on normalizing the distance between the destination and position and thereafter scaling.
#### Usage
To make the Drone fly, in our example, a speed of 1 m/s, we write:

```packageOne.Fly()```

which changes the position of our Drone to the new position.
## 🌏 Airspace Class
The Airspace contains the a variety of methods to interact with a multitude of Drones simultaneously.

Let's build a new Airspace, do it in the same file (example.fsx):

```let airspace = new Airspace()```

### addDrone drone
Adds a given Drone to our Drone list.

#### Usage
```airspace.addDrone exampleDrone```

Adds an individual Drone to the airspace.

### addDrones (list: Drone list)
Loops through the list of Drones given in input and adds them individually with the ```addDrone``` method. 
#### Usage
In our example from the Drone class we can use those in our new airspace:

```airspace.addDrones ([packageOne, packageTwo])```

which adds the drones to the list of drones in the airspace class.

### droneDist (d1: Drone) (d2 : Drone)
To get the distance between two Drones in the Airspace:

#### Usage
```airspace.DroneDist (packageOne) (packageTwo) ```

which returns the distance between two given Drones.

### getDrones() 
To get the list of the current Drones in the airspace we write:

#### Usage
```airspace.getDrones()```

which returns the list of Drones, as we previously set in our example to be ```packageOne``` and ```packageTwo```.

### flyDrones() 
Loops through the list of each individual Drone and calls the Drone ```Fly()``` method on each index:

#### Usage
```airspace.flyDrones()```

gives a new position to each individual drone based on their own properties. 
### willCollide (loop: int) 
Given a m/s time interval, we choose the total of seconds we are simulating.
#### Usage

```airspace.willCollide(10)```

where it would fly the Drones for 10 seconds and check if either of them are in a 5 meter proximity of one another, if they are with-in proximity the function returns a list of the drones whom have collided.


# Compiling the application
To compile the application we make use of the commands:

Compiling simulate.fs to an DLL-library

```fsharpc -a simulate.fs```

Creating an executable file with both the DLL-library and .fsx file, you can change the fsx file whichever .fsx file you are utilizing the applicaton with.

## Remark on usage of module Simulating Drones
If you have an .fsx file you want to start the first line by utilizing the module: 

```module SimulatingDrones```

thereafter you can compile the library simulate.dll with your .fsx file as such:

```fsharpc -r simulate.dll testSimulate.fsx```
# Running the application
After compiling you can run your application by typing:

```mono testSimulate.exe```
