import { Outlet, Route, Routes } from "react-router-dom"
import "./App.css"
import React from "react"
import { Nav } from "./Nav"
import { StylistList } from "./components/StylistList"
import { AppointmentList } from "./components/AppointmentList"




export const App = () => {
  return <>
    <Routes>
    <Route path="/" element={
            <>
                <Nav />
                <Outlet />
            </>
            
        }>
      
      <Route path="/appointments" element={<AppointmentList/>}> 
      
      </Route>
      <Route path="/appointments/:id" element={<>Appointment Details</>}></Route>
      <Route path="/stylists" element={<StylistList/>} />
      <Route path="/customers" element={<>Customers</>} />
      
      </Route>
    </Routes>
  </>
}


export default App
