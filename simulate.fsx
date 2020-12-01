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
    let mutable UUID = "Package - " + UUID


    member this.NewPosition () = (normVector(dest +- position) +@ speed)
    member this.Fly () = 
    if (vectorLength(dest +- position) <= speed) then
        printfn "%s %s %A" UUID "- Has overshot and flown back to its destination:" destination
        position <- dest
        ()
    else
        if(vectorLength(dest +- position) > speed) then 
            printfn "%s %s %A" UUID "- Has reached its destination. " destination
            position <- dest
            ()
        else 
            printfn "%s %s %A" UUID "- Is still flying at position: " position
            position <- position +| this.NewPosition(); position
            ()

type Airspace () = 
    let mutable drones : Drone list = []

    member this.droneDist d1 d2 = 
        let pos1 = d1.position
        let pos2 = d2.position
        (vectorLength(pos1 +- pos2))
            
    member this.flyDrones = 
        for i in[0..(drones.Length - 1)] do
            drones.[i].Fly()

    member this.addDrone drone = 
        drones <- drones @ drone

    member this.willCollide =
        let mutable collidedDrone : (Drone*Drone) list = []

        for i in [0..(drones.Length - 1)] do
            for j in [i+1..(drones.Length - 1)] do
                if(this.droneDist i j <= 5) then
                    collidedDrone <- collidedDrone @ (i, j) 
                else


let drone1 = new Drone((upwards +@ 15.), (origin), 16., "Queen-sized bed")
drone1.Fly()