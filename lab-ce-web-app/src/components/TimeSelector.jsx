import React, { useState } from 'react';

function TimeSelector({ onTimeSelect }) {
    const times = ['8:00 am', '10:00 am', '1:00 pm', '3:00 pm'];

    return (
        <div className="time-selector">
            {times.map((time, index) => (
                <button
                    key={index}
                    //className={`time-option ${selectedTime === time ? 'selected' : ''}`}
                    onClick={() => onTimeSelect(time)}
                >
                    {time}
                </button>
            ))}
        </div>
    );
};


export default TimeSelector;