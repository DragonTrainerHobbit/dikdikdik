
let nevek=["Éva","Géza","Ágnes","Elek","Ella","Zénó"]
let lakhelyek=["Orosháza","Debrecen","Miskolc","Telkibánya","Győr","Kistelek"]
let pictures=["1.jpg","2.jpg","3.jpg","4.jpg","5.jpg","6.jpg"]

let adatok=[]

function rnd(min,max){
    return Math.floor(Math.random()*(max-min))+min
}

for(i=0;i<100;i++){
    let ember=new Ember(
        nevek[rnd(0,nevek.length)],
        lakhelyek[rnd(0,lakhelyek.length)],
        rnd(1,40),
        pictures[rnd(0,pictures.length)],
        "pics"

    )
    adatok.push(ember)
}

console.log(adatok)

//Math.random() - 0 és 1 közötti számot ad
//Math.floor() - kerekítés