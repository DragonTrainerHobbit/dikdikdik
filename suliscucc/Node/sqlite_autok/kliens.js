const fetch=require('cross-fetch');

let ujauto={
    rendszam:"zqk-699",
    marka:"Opel",
    tipus:"Corsa",
    szin:"zöld",
    gyartasiev:2006
}

let updateauto={
    rendszam:"zqk-699",
    marka:"Volkswagen",
    tipus:"Touran",
    szin:"szürke",
    gyartasiev:2009
}

async function ujadat(){

    const res=await fetch('http://127.0.0.1:8000/ujauto',{
        method:'post',
        headers:{'Content-type':'application/json'},
        body:JSON.stringify(ujauto)
    });

    const valasz=await res.json();

    console.log(valasz);

}

async function updateadat(){

    const res=await fetch('http://127.0.0.1:8000/updateauto',{
        method:'put',
        headers:{'Content-type':'application/json'},
        body:JSON.stringify(updateauto)
    });

    const valasz=await res.json();

    console.log(valasz);

}

async function deleteadat(){

    const res=await fetch('http://127.0.0.1:8000/deleteauto',{
        method:'delete',
        headers:{'Content-type':'application/json'},
        body:JSON.stringify(updateauto)
    });

    const valasz=await res.json();

    console.log(valasz);

}

//ujadat();
//updateadat();
deleteadat();
