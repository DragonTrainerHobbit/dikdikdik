import Rick from '../images/rick.jpeg';
import Morty from '../images/morty.png';
function Header(){
    return (
        <div className="container bg-dark">
            <div className="row align-items-center">
                <div className="col text-white">
                    <h1>Rick és <span className="text-warning"> Morty</span></h1>
                </div>
                <div className="col">
                    <img src={Rick} className="rounded-circle w-25 p-2"></img>
                    <img src={Morty} className="rounded-circle w-25 p-2"></img>
                </div>

            </div>
        </div>
    );
}
export default Header;