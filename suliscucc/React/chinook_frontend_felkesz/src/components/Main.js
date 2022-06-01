import Bg from './bg.jpg';
import {NavLink} from 'react-router-dom';

function Main() {
  return (
    <section className="h-screen p-4 bg-neutral-400 bg-no-repeat bg-center bg-fixed" style={{backgroundImage: `url(${Bg})`}}>
        <div>
        <NavLink to={'/artists'} className="bg-neutral-100 text-5xl text-center">Előadók listázása</NavLink>        
        </div>
    </section>
  )
}

export default Main;