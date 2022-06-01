function App(){
    return React.createElement(
        'div',
        {},
        React.createElement(Box,{hatterszin:"red",felirat:"Box1",szam:8}),
        React.createElement(Box,{hatterszin:"green",felirat:"Box2",szam:12}),
        React.createElement(Box,{hatterszin:"yellow",felirat:"Box3",szam:-1}),
        React.createElement(Box,{hatterszin:"blue",felirat:"Box4",szam:111}),
        
    );

}

function Box({hatterszin,felirat,szam}){
    const [szamlalo,setSzamlalo]=React.useState(szam);
    return React.createElement(
        'div',
        {
            style:{
                width:"200px",
                height:"200px",
                margin:"10px",
                backgroundColor:hatterszin
            },
            onClick:()=>{setSzamlalo(elozo=>elozo+1)}
        },
        React.createElement('h1',{},felirat),
        React.createElement('h2',{},"Számláló:"+szamlalo)
    );

}

ReactDOM.render(React.createElement(App),document.getElementById('app-container'));