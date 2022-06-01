const gomb=React.createElement(
    'button',
    {onClick:()=>{alert("Button")}},
    "Gomb"
);


const kontener=React.createElement(
    'div',
    {},
    gomb,
    gomb,
    gomb,
    gomb

)


ReactDOM.render(kontener,document.getElementById('react-button-container'));