function App(){
    const szam=10;
    const szamok=[10,233,567,55,77,219,345,1154,889,1123,556];
    const [ertek,setErtek]=React.useState(0);
    const [lathato,setLathato]=React.useState(true);
    

    return <div>
        <h1>Jsx szintaxis</h1>
        <h2>Szám:{ertek}</h2>
        {lathato ? <ul>{szamok.map(szam=><li>{szam}</li>)}</ul> : <ul></ul>}
        
        <button onClick={()=>setErtek(elozo=>elozo+10)} >Növelés</button>
        <button onClick={()=>setErtek(elozo=>elozo-10)} >Csökkentés</button>
        <button onClick={()=>setErtek(0)} >Alapérték</button>
        <button onClick={()=>setLathato(!lathato)}>Lista kapcsolás</button>

        
    </div>
}

ReactDOM.render(<App />,document.getElementById('app-container'));
