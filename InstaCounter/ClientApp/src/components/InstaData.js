import React, { useState } from 'react';


function InstaData() {
    const [data, setData] = useState();
    const greeting = 'Hello Function Component!';
    getData();
    return <Headline value={data} />;
}


function Headline({ data }) {
    
    return <h1>{data}</h1>;
}

const getData =  async () => {
    const response = await fetch('getInstaData');
    const res = await response.json();
    this.setData(res);
};

export default InstaData;