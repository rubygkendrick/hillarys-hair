import { Outlet, Route, Routes } from "react-router-dom"
import "./App.css"
import React from "react"
import { Nav } from "./Nav"
import { StylistList } from "./components/StylistList"




export const App = () => {
  return <>
    <Routes>
    <Route path="/" element={
            <>
                <Nav />
                <Outlet />
            </>
            
        }>
      
      <Route path="/appointments" element={<>Appointments</>} />
      <Route path="/stylists" element={<StylistList/>} />
      <Route path="/customers" element={<>Customers</>} />
      </Route>
    </Routes>
  </>
}


export default App
