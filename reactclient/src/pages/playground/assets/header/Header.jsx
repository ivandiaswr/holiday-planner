import "./header.css"
import { Link } from "react-router-dom"

export default function Header() {


    return (
        <header>
            <nav className="playground-nav">
                <h2>Holiday Planner - Playground</h2>
                <h3><Link to="/" className="home-button">Home</Link></h3>
            </nav>
        </header>
    )
}