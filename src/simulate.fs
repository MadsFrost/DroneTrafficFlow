module AttackerDrones

type vec = float*float

let origin : vec = (0.,0.)
let upwards : vec = (0.,1.)
let right : vec = (1.,0.)
let downwards : vec = (0.,-1.)
let left : vec = (-1.,0.)

// Scale the vector with a float
let (+@) (A:vec) (B:float) : vec =
    (fst A*B, snd A*B)

// Add two vectors together
let (+|) (A:vec) (B:vec) : vec = 
    (fst A + fst B, snd A + snd B)

// Subtract two vectors from eachother
let (+-) (A:vec) (B:vec) : vec =
    (fst A - fst B, snd A - snd B)

let vectorLength (A:vec) : float =
    sqrt(fst A**2. + snd A**2.)

let normVector (A:vec) : vec =
    let length = vectorLength A 
    (fst A / length, snd A / length)

let testVector : vec = (0.,1.)



type Drone (startpos:vec, dest:vec, speed:float, UUID:string) = 
    let mutable position = (startpos)
    let mutable destination = (dest)
    let mutable speed = speed
    let mutable UUID = UUID
    let mutable finished = false

    member this.getSpeed() = speed
    member this.setFinished () = finished <- true
    ///<summary>Checks boolean of drone finished</summary>
    ///<param name="()">A unit for running the method</param>
    ///<returns>A boolean bashed on whether the drone has finished flying</returns>
    member this.isFinished () = finished
    member this.getUUID () = UUID
    member this.getPosition() = position
    member this.getDestination() = destination
    member this.newPosition () = (normVector(dest +- position) +@ speed)
    
    ///<summary>Moves drone to a new position based on speed</summary>
    ///<param name="()">Unit for running the method</param>
    ///<returns>New position which is assigned to the position property</returns>
    
    member this.Fly () = 
        if (this.isFinished() = true) then
            ()
        else
            if (vectorLength(dest +- position) < speed) then
                position <- dest
                finished <- true
                ()
            else
                if(vectorLength(dest +- position) = speed) then 
                    position <- dest
                    finished <- true
                    ()
                else 
                    position <- position +| this.newPosition(); position
                    ()


type Airspace () = 
    let mutable drones : Drone list = []

    ///<summary>Prints a float from a list, based on contiued fractions</summary>
    ///<param name="a">The float as input parameter</param>
    ///<returns>An integer list from using the continued fractions</returns>
    member this.droneDist (d1: Drone) (d2 : Drone) = 
        let pos1 = d1.getPosition()
        let pos2 = d2.getPosition()
        (vectorLength(pos1 +- pos2))

    ///<summary>Prints a float from a list, based on contiued fractions</summary>
    ///<param name="a">The float as input parameter</param>
    ///<returns>An integer list from using the continued fractions</returns>
    member this.getDrones() = drones

    ///<summary>Prints a float from a list, based on contiued fractions</summary>
    ///<param name="a">The float as input parameter</param>
    ///<returns>An integer list from using the continued fractions</returns>
    member this.flyDrones () = 
        for i in[0..(drones.Length - 1)] do
            drones.[i].Fly()

    ///<summary>Prints a float from a list, based on contiued fractions</summary>
    ///<param name="a">The float as input parameter</param>
    ///<returns>An integer list from using the continued fractions</returns>
    member this.addDrone drone = 
        drones <- drones @ [drone]

    ///<summary>Prints a float from a list, based on contiued fractions</summary>
    ///<param name="a">The float as input parameter</param>
    ///<returns>An integer list from using the continued fractions</returns>
    member this.addDrones (list: Drone list) = 
        for i in [0..(list.Length - 1)] do
            this.addDrone (list.[i])

    ///<summary>Prints a float from a list, based on contiued fractions</summary>
    ///<param name="a">The float as input parameter</param>
    ///<returns>An integer list from using the continued fractions</returns>
    member this.willCollide (loop: int) : (Drone*Drone) list =
        let mutable collidedDrone : (Drone*Drone) list = []
        for x in 0..loop - 1 do
            this.flyDrones()
            for i in [0..(drones.Length - 1)] do
                for j in [i+1..(drones.Length - 1)] do
                    
                    if((this.droneDist(drones.[i])(drones.[j])) <= 5. && not ((drones.[i].isFinished()) || drones.[j].isFinished())) then
                        collidedDrone <- collidedDrone @ [drones.[i], drones.[j]]
                        (drones.[i].setFinished())
                        (drones.[j].setFinished())
                        printfn "%A %A %s %A %A" (drones.[i].getUUID()) (drones.[j].getUUID()) "Collided at: " (drones.[i].getPosition()) (drones.[j].getPosition())
                        ()
                    else
                        ()
        collidedDrone

