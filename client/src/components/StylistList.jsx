import { useEffect, useState } from "react"

import { editStylistStatus, getAllStylists } from "../data/stylistData"

export const StylistList = () => {

    const [allStylists, setAllStylists] = useState([])


    const getAndResetAllStylists = () => {
        getAllStylists().then(stylistsArray => {
            setAllStylists(stylistsArray)
        })
    }

    useEffect(() => {
        getAndResetAllStylists()
    }, [])

    const handleButtonClick = (event) => {
        editStylistStatus(event.target.value).then(() => {
            getAndResetAllStylists();
        })
    }

    return (
        <div>
            <h1>Stylists</h1>
            {allStylists.map((stylist) => (
                <div key={stylist.id} >

                    <h2>{stylist.name}</h2>

                    <p>Status: {stylist.isActive == true ? "Active" : "Inactive"}</p>
                    {stylist.isActive ? (
                        <button 
                        value={stylist.id}
                        onClick={handleButtonClick}
                        className="btn-primary">Deactivate</button>
                    ) : (
                        <button 
                        value={stylist.id}
                        onClick={handleButtonClick}
                        className="btn-primary">Activate</button>
                    )}
                </div>
            ))}
        </div>
    )
}