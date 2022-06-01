//Hagyományos,natív javascript
const btn=document.createElement('button');

btn.onclick=function(){
    alert("Js gomb");
}
btn.textContent="Js gomb";

document.getElementById('js-button-container').appendChild(btn);

//Ugyanez, React használatával

const reactGomb=React.createElement(
    'button',
    {
        onClick:function(){
            alert("React gomb");
        }
    },
    "React gomb"
);

ReactDOM.render(reactGomb,document.getElementById('react-button-container'));