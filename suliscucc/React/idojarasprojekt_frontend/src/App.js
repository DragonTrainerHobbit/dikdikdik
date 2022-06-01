import { useState,useEffect } from 'react';
import './App.css';
import Header from './components/Header';
import List from './components/List';
import Ujadat from './components/Ujadat';

function App() {
  const [idoAdatok,setIdoAdatok]=useState([]);
  const ev=2011;

  useEffect(()=>{
    fetch(`http://127.0.0.1:8000/ev/${ev}`)
    .then(res=>res.json())
    .then(adatok=>setIdoAdatok(adatok))
    .catch(err=>console.log(err));
  },[]);

  const ujAdat=async function(ujnap){
    const res=await fetch('http://127.0.0.1:8000/ujnap',{
      method:'post',
      headers:{'Content-type':'application/json'},
      body:JSON.stringify(ujnap)
    }
    );
    const valasz=await res.json();
    alert(valasz.message);
    //ha olyan jellegű a listánk, akkor az adatok közé is
    //fel kell venni az új adatot
    //setIdoAdatok([...idoAdatok,ujnap]);
  }

  return (
    <div className="container">
            
      <section className="bg-primary text-white">      
      <Header oldalCim={'Időjárás frontend'} />
      
      </section>
      <section className="bg-dark text-white">
      <Ujadat ujAdat={ujAdat} />
      
      <p>Adatok száma:{idoAdatok.length}</p>
      </section>
      <div className="container-sm">
      <List lista={idoAdatok} />
      </div>
      
    </div>
  );
}

export default App;
