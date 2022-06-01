console.log("Hello");
const express=require('express');
const app=express();
const fetch=require('cross-fetch');

app.set('view-engine','ejs');
app.listen(8000,()=>{console.log("A szerver fut")})


app.get('/',(req,res)=>{
    res.send("Hello, node szerver vagyok");
})

app.get('/info',(req,res)=>{
    res.send("Info oldal");
})

app.get('/minta',(req,res)=>{
    res.render('minta.ejs',{nev:"Valaki,bárki,akárki"});
})

app.get('/adatok',(req,res)=>{

    fetch('https://randomuser.me/api/?results=50')
    .then(results=>results.json())
    .then(data=>{
        res.render('adat.ejs',{adatok:data});
        //console.log(data)
    })
})


app.get('/adatok/:adatszam',(req,res)=>{
        const szam=req.params.adatszam

        fetch('https://randomuser.me/api/?results='+szam)
        .then(results=>results.json())
        .then(data=>{
            res.render('adat.ejs',{adatok:data});
            //console.log(data)
       })
})   
    

