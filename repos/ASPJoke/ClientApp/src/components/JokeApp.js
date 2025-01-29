import React, { useState } from "react";

const JokeApp = () => {
    const [joke, setJoke] = useState("");
    const [rating, setRating] = useState(0);

    const getRandomJoke = async () => {
        console.log("Haha")
        try {
            const response = await fetch("https://localhost:44372/api/jokes");
            //const response = await fetch("https://api.chucknorris.io/jokes/random");
            if (response.ok) {
                const data = await response.json();
                console.log(data)
                setJoke(data.value);
                setRating(0);
            } else {
                console.error("Failed to retrieve a joke");
            }
        } catch (error) {
            console.error(error);
        }
    };

    const rateJoke = async () => {
        try {
            const response = await fetch("/api/jokes", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ joke, rating }),
            });
            if (response.ok) {
                console.log("Joke saved with rating:", rating);
            } else {
                console.error("Failed to save the joke");
            }
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <div>
            <h1>Joke App</h1>
            <button onClick={getRandomJoke}>Get Joke</button>
            <p>{joke}</p>
            <div>
                <span>Rate the Joke: </span>
                {[1, 2, 3, 4, 5].map((star) => (
                    <span
                        key={star}
                        onClick={() => setRating(star)}
                        style={{ color: star <= rating ? "gold" : "gray", cursor: "pointer" }}
                    >
                        ★
                    </span>
                ))}
            </div>
            <button onClick={rateJoke}>Save Joke</button>
        </div>
    );
};

export default JokeApp;
