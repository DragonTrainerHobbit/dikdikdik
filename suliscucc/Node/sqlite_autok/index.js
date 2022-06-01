const express=require('express');
const app=express();
const sqlite3=require('sqlite3');
const cors=require('cors');
const db_repo=require('./dbfunc');
const db=new sqlite3.Database('./autok.db');

 
app.use(cors());
app.use(express.urlencoded({extended:true}));
app.use(express.json());

app.listen(8000,()=>{
    console.log("Fut a szerver");
});

app.get('/',(req,res)=>{
    res.send("Autók adatbázis");
});

app.get('/alldata',async(req,res)=>{
    
    db_repo.db_all(db)
    .then(eredmeny=>{res.json(eredmeny)})
    .catch(error=>{res.send(error)});
    
});


app.post('/ujauto',async (req,res)=>{
    
    db_repo.db_insert(db,req.body)
    .then(eredmeny=>{res.status(200).json(eredmeny)})
    .catch(error=>{res.send(error)});
           
        
});

app.put('/updateauto',async (req,res)=>{

    db_repo.db_update(db,req.body)
    .then(eredmeny=>{res.status(200).json(eredmeny)})
    .catch(error=>{res.send(error)});

});

app.delete('/deleteauto',async(req,res)=>{

    db_repo.db_delete(db,req.body)
    .then(eredmeny=>{res.status(200).json(eredmeny)})
    .catch(error=>{res.send(error)});
});