type vec = float*float

//Scale a vector A by a length B
let (+*) (A:vec) (B:float) : vec =
    (fst A * B, snd A * B)

//Add two vectors A & B
let (++) (A:vec) (B:vec) : vec =
    (fst A + fst B, snd A + snd B)

//Subtract two vectors A & B
let (+-) (A:vec) (B:vec) : vec =
    (fst A - fst B, snd A - snd B)

//Get length of a vector
let length (A:vec) : float =
    sqrt (fst A**2. + snd A**2.)

//Get vector in same direction but with length 1
let normalize (A:vec) : vec =
    let len = length A
    (fst A / len, snd A / len)

let start : vec = (0.,2.)
let slutt : vec = (3.,3.)
let speed = 2.5
// k^2 + k^2 = h^2 


let path = slutt +- start  
let lengde = sqrt((fst path)**2. + (snd path)**2.) 

let normPath = (normalize(path))
let newPath = (normPath +* speed)

let cordNewPath = (start ++ newPath)

printfn "%A %A" start slutt
printfn "%A" newPath
printfn "%A" cordNewPath




printfn "%A" (normalize(path))
printfn "%A" (length(normalize(path)))
printfn "%A" (length(normalize(path)+*2.5))