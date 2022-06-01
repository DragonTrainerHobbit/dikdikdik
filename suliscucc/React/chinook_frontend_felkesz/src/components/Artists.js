import {useState,useEffect} from 'react';
import { Link } from 'react-router-dom';
import Artist from './Artist';
function Artists() {
    const[artists,setArtists]=useState([]);

    useEffect(()=>{
        fetch('http://localhost:8000/artists')
        .then(res=>res.json())
        .then(zeneszek=>setArtists(zeneszek))
        .catch(err=>console.log(err))
    },[]);


  return (
    <div className="grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 justify-items-stretch">
        <Link to={'/'}>Vissza a főoldalra</Link>
        {artists.map((artist,index)=>(<Artist artist={artist}/>))}

    </div>
  )
}

export default Artists;