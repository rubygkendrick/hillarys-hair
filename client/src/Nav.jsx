import { Link } from "react-router-dom"
import "./Nav.css"


export const Nav = () => {
   
    return (
        <ul className="navbar">
            <li className="navbar-item">
                <Link to="/">Hillarys Hair
                </Link>
            </li>
            <li className="navbar-item">
                <Link to="/appointments">Appointments</Link>
            </li>
            <li className="navbar-item">
                <Link to="/stylists">Stylists</Link>
            </li>
            <li className="navbar-item">
                <Link to="/customers">Customers</Link>
            </li>
            
        </ul>
    )
}