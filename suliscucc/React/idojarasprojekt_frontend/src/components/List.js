import Listitem from "./Listitem";

function List({lista}){

    return (
        <div>
            {lista.map((elem)=>(<Listitem elem={elem} />))}
        </div>
    );
    
}
export default List;