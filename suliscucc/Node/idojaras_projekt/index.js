const express=require('express');
const app=express();
const cors=require('cors');
const sqlite3=require('sqlite3');

const { mindenAdat, getEv, getNap, insertNap } = require('./dbfunctions');
const db=new sqlite3.Database('./idojarasadatok.db');

app.use(cors());
app.use(express.urlencoded({extended:true}));
app.use(express.json());

app.listen(8000,()=>{console.log("A szerver fut")});

app.get('/',(req,res)=>{
    res.send("<H2>Időjárás adatok</H2>");
});

app.get('/mindenadat',async (req,res)=>{
    mindenAdat(db)
    .then(sorok=>res.json(sorok))
    .catch(err=>res.send(err));
});

app.get('/ev/:ev',async (req,res)=>{
    const ev=req.params.ev;
    getEv(db,ev)
    .then(sorok=>res.json(sorok))
    .catch(err=>res.send(err));
});

app.get('/ev/:ev/honap/:honap/nap/:nap',async (req,res)=>{
    getNap(db,req.params.ev,req.params.honap,req.params.nap)
    .then(sorok=>res.json(sorok))
    .catch(err=>res.send(err));
});

app.post('/ujnap',(req,res)=>{
    insertNap(db,req.body)
    .then(eredmeny=>res.status(201).json(eredmeny))
    .catch(err=>res.send(err));
});