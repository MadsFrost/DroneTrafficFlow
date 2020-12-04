# Simulating Drones
## Documentation
### willCollide Design
The willCollide 
## Functions

## Compiling the application
To compile the application we make use of the commands:

Compiling simulate.fs to an DLL-library
```fsharpc -a simulate.fs```

Creating an executable file with both the DLL-library and .fsx file
```fsharpc -r simulate.dll testSimulate.fsx```
## Running the application
After compiling you can run your application by typing:
```mono testSimulate.exe```
