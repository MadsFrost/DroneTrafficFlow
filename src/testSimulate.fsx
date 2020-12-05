open SimulatingDrones

printfn "=============================================\nWhitebox testing of Drone Class Methods \n============================================="
printfn "\n======================================\n Testing of method isFinished \n======================================\n"
let d1 = new Drone((upwards +@ 7.), (origin), 1., "Drone A")
let d2 = new Drone((upwards +@ 14.), (origin), 1., "Drone B")
let d3 = new Drone((upwards +@ 1.), (origin), 1., "Drone C")
let a1 = new Airspace()
a1.addDrones([d1;d2;d3])
a1.willCollide(14)
printfn "%5b %5b %5b: Branch 1a - Is Finished after flying to destination \n" (d1.isFinished()) (d2.isFinished()) (d3.isFinished())

printfn "========================== \n Testing of method fly \n========================== \n"
let d4 = new Drone((downwards +@ 0.9), (origin), 1., "Drone A")
let d5 = new Drone((upwards +@ 2.), (origin), 1., "Drone B")
let a2 = new Airspace()
d4.Fly()
d5.Fly()
a2.addDrones([d4;d5])
a2.willCollide(2)

printfn "Drone with coordinates position and destination: %s %s" "(0., -0.9.)" "(0., 0.)"
printfn "%5b: Branch 1a - Finished" (d4.isFinished())
printfn "%5b: Branch 1b - Not Finished" (d4.isFinished() = false)
printfn "%5b: Branch 2a - Overshooting" (vectorLength(d4.getDestination() +- d4.getPosition()) < d4.getSpeed())
printfn "%5b: Branch 2b - Reached Destination" ((vectorLength(d4.getDestination() +- d4.getPosition())) = (d4.getSpeed()))

printfn "\n"
printfn "Drone with coordinates position and destination: %A %A" "(0., 2.)" "(0., 0.)"
printfn "%5b: Branch 1a - Finished" (d5.isFinished())
printfn "%5b: Branch 1b - Not Finished" (d5.isFinished() = false)
printfn "%5b: Branch 2a - Overshooting" (vectorLength(d5.getDestination() +- d5.getPosition()) < d5.getSpeed())
printfn "%5b: Branch 2b - Reached Destination" ((vectorLength(d5.getDestination() +- d5.getPosition())) = (d5.getSpeed()))

printfn "\n \n=============================================\nWhitebox testing of Airspace Class Methods \n============================================="
printfn "\n======================================\n Testing of method droneDist \n======================================\n"
let d6 = new Drone((upwards +@ 1.), (origin), 1., "Drone A")
let d7 = new Drone((upwards +@ 2.), (origin), 1., "Drone B")

let a3 = new Airspace()
a3.addDrones([d6;d7])
printfn "Distance between drones: %A %A %s" "(0., 1.)" "(0., 2.)" "= 1.0"
printfn "%5b: Branch 1a - Distance" (a3.droneDist(d6)(d7) = 1.0)


printfn "\n======================================\n Testing of method flyDrones \n======================================\n"
printfn "Flying Drones: %s" "(0., 1.) & (0., 2.) = (0., 0) & (0., 1)"
a3.flyDrones()
printfn "%5b: Branch 1a - Distance" (d6.getPosition() = (0., 0.))

printfn "\n======================================\n Testing of method addDrones \n======================================\n"
let d8 = new Drone((right +@ 2.), (origin), 1., "Drone A")
a3.addDrones([d8])
printfn "Add Drones: %s" "( d8 = a3.getDrones().[2])"
printfn "Branch 1a: %A" ( d8 = a3.getDrones().[2])

printfn "\n======================================\n Testing of method willCollide \n======================================\n"
let a4 = new Airspace()
let d9 = new Drone((right +@ 7.), (origin), 1., "Drone A")
let d10 = new Drone((downwards +@ 10.), (origin), 2., "Drone B")
a4.addDrones([d9;d10])
let shouldCollide : (Drone*Drone) list = [d9,d10]
printfn "Does crash: %s" "(3.0, 0.0) (0.0, -2.0)"
printfn "Branch 1a - Does crash: %A" (a4.willCollide(4) = shouldCollide)
printfn "Does not crash: %s" "(0, -9) (6, 0.0)"
printfn "Branch 1b - Does not crash: %A" (a4.willCollide(1) = [])

