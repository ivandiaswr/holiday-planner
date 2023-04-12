import { FaBars, FaTimes } from 'react-icons/fa'
import { useState } from "react"
import { Link } from "react-router-dom"
import "./header.css"

import holidayIMG from "../../../../img/holidays-icon.png"

export default function Header() {
    const [visibilityNav, setVisibilityNav] = useState('hidden');
    const [displayTimes, setDisplayTimes] = useState('none');
    const [displayBars, setDisplayBars] = useState('block');

    const OpenNav = () => {
        setVisibilityNav('visible');
        setDisplayBars('none');
        setDisplayTimes('block');
    }

    const CloseNav = () => {
        setVisibilityNav('hidden');
        setDisplayTimes('none');
        setDisplayBars('block'); 
    }

    return (
        <header>
            <nav className="navbar">
                <div className="nav-left">
                    <img src={ holidayIMG } alt="" title=""></img>
                    <div>
                        <h2>Holiday</h2>
                        <p>Planner</p>
                    </div>
                </div>
                <ul className="navbar-list" style={{ visibility: visibilityNav }}>
                    <li><a href="#welcome" onClick={CloseNav}>Welcome</a></li>
                    <li><a href="#funcionalities"onClick={CloseNav}>Funcionalities</a></li>
                    <li><a href="#roadmap" onClick={CloseNav}>Roadmap</a></li>
                    <li><a href="#contact" onClick={CloseNav}>Contact</a></li>
                    <li><Link to="/playground" onClick={CloseNav}>Playground</Link></li>
                </ul>
            </nav>
            <div className="navbar-buttons">
                <button onClick={OpenNav} style={{ display: displayBars }}>
                    <FaBars className="navbar-open-button" /> 
                </button>
                <button onClick={CloseNav} style={{ display: displayTimes }}>
                    <FaTimes className="navbar-close-button"/>
                </button>
            </div> 
        </header>
    )
}