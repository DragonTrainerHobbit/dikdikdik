const express=require('express');
const app=express();
const fetch=require('cross-fetch');

app.set('view-engine','ejs');
app.listen(8000,()=>{
    console.log("Fut a szerver");
});

app.get('/',(req,res)=>{
    res.send("<H2>Üdvözli a node szerver!</H2>");
});

app.get('/nevsor',(req,res)=>{
    
    fetch('https://randomuser.me/api?results=50').
    then(res=>res.json()).
    then(data=>{
        res.json(data);
    });
    
});

app.get('/nevsorhtml',(req,res)=>{
    fetch('https://randomuser.me/api?results=50').
    then(res=>res.json()).
    then(data=>{
        res.render('nevsor.ejs',{adatok:data});
    });
});

app.get('/nevsorhtml/:db',(req,res)=>{

    let db=req.params.db;

    fetch('https://randomuser.me/api?results='+db).
    then(res=>res.json()).
    then(data=>{
        res.render('nevsor.ejs',{adatok:data});
    });
});