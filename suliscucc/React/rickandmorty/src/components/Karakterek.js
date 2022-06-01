import {useState,useEffect} from 'react';
import KarakterCard from './KarakterCard';


function Karakterek(){
    const [charList,setCharList]=useState([]);
    const [page,setPage]=useState(1);

    const eloreClick=()=>{setPage(elozo=>elozo+1);
        console.log(page);
    };

    const visszaClick=()=>{
        if(page>1){
            setPage(elozo=>elozo-1);
            console.log(page);
        }
    };
    
    useEffect(()=>{
        fetch(`https://rickandmortyapi.com/api/character?page=${page}`)
        .then(res=>res.json())
        .then(adatok=>setCharList(adatok.results))
    },[page]);

    return (
        <div className="bg-light d-flex align-items-center flex-column">
            <h1>Karakterek</h1>
            <div className="row">
                <div className="col fs-3" onClick={visszaClick}><i class="bi bi-skip-backward"></i></div>
                <div className="col fs-3" onClick={eloreClick}><i class="bi bi-skip-forward"></i></div>
            </div>
            {charList.map((character)=>(<KarakterCard character={character}/>))}
        </div>
    );
}

export default Karakterek;