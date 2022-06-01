const express=require('express');
const cors=require('cors');
const app=express();
const sqlite3=require('sqlite3');
const  db_repo  = require('./dbfunc');
const db=new sqlite3.Database('./idojarasadatok.db');

app.use(cors());
app.use(express.urlencoded({extended:true}));
app.use(express.json());

app.listen(8000,()=>{console.log('A szerver fut')});

app.get('/',(req,res)=>{
    res.send('Időjárás adatok adatbázis');
});

app.get('/alldata',async (req,res)=>{
    db_repo.db_all().then(records=>res.json(records)).catch(err=>res.send(err));
});



app.get('/ev/:ev',async (req,res)=>{

    
    db_repo.query_ev(db,req.params.ev)
    .then(records=>res.json(records))
    .catch(err=>res.send(err));

});

app.get('/ev/:ev/honap/:honap/nap/:nap',async (req,res)=>{

    
    db_repo.query_nap(db,req.params.ev,req.params.honap,req.params.nap)
    .then(records=>res.json(records))
    .catch(err=>res.send(err));

});