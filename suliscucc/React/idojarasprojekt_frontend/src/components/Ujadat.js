import {useState} from 'react';
function Ujadat({ujAdat}){

    const onSubmit=(e)=>{
        e.preventDefault();
        ujAdat({ev,honap,nap,ora,homerseklet,szelsebesseg,paratartalom})
        setEv(0);
        setHonap(0);
        setNap(0);
        setOra(0);
        setHomerseklet(0);
        setSzelsebesseg(0);
        setParatartalom(0);

    }

    const [ev,setEv]=useState(0);
    const [honap,setHonap]=useState(0);
    const [nap,setNap]=useState(0);
    const [ora,setOra]=useState(0);
    const [homerseklet,setHomerseklet]=useState(0);
    const [szelsebesseg,setSzelsebesseg]=useState(0);
    const [paratartalom,setParatartalom]=useState(0);

    return (
        <div>
            <form onSubmit={onSubmit}>
                <div>
                    <label>Év:</label>
                    <input type="text" value={ev} onChange={(e)=>setEv(e.target.value)}/>
                </div>
                <div>
                    <label>Hónap:</label>
                    <input type="text" value={honap} onChange={(e)=>setHonap(e.target.value)}/>
                </div>
                <div>
                    <label>Nap:</label>
                    <input type="text" value={nap} onChange={(e)=>setNap(e.target.value)}/>
                </div>
                <div>
                    <label>Óra:</label>
                    <input type="text" value={ora} onChange={(e)=>setOra(e.target.value)}/>
                </div>
                <div>
                    <label>Hőmérséklet:</label>
                    <input type="text" value={homerseklet} onChange={(e)=>setHomerseklet(e.target.value)}/>
                </div>
                <div>
                    <label>Szélsebesség:</label>
                    <input type="text" value={szelsebesseg} onChange={(e)=>setSzelsebesseg(e.target.value)}/>
                </div>
                <div>
                    <label>Páratartalom:</label>
                    <input type="text" value={paratartalom} onChange={(e)=>setParatartalom(e.target.value)}/>
                </div>
                <input type="submit" value="Új adat"/>
            </form>
        </div>
    );
}
export default Ujadat;