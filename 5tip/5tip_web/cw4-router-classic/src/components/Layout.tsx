import React from 'react'
import { NavLink } from 'react-router'

type Props = {}

const Layout = (props: Props) => {
  return (
    <nav>
        <ul className='d-flex gap-3' style={{listStyle:'none'}}>
            <li>
                <NavLink to="/">Home</NavLink>
            </li>
            <li>
                <NavLink to="/about">About</NavLink>
            </li>
            <li>
                <NavLink to="/contact">Contact</NavLink>
            </li>       
        </ul>
    </nav>
  )
}

export default Layout   