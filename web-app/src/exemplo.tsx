import React, { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

/*type TitleProps = {
  text: string;
}

const Title = ({ text }: TitleProps) => {
  return <h1>{text}</h1>;
};

const Idade = ({ idade }: { idade: any }) => {
  return <h2>{idade}</h2>
};

type TitleProps = {
  children: React.ReactNode;
  size?: "small" | "large";
}*/

const user = {
  id: 1,
  name: "Luana Thurow",
  age: 22,
  isAdmin: true,
  bithDate: new Date("2003-24-02")
};

type UserAttributes = typeof user;

const Mayra: UserAttributes = {
  id: 2,
  name: "Mayra Bordin",
  age: 22,
  isAdmin: false,
  bithDate: new Date("2003-07-07")
}

// não é preciso falar o tipo do retorno
function sumNumbers(a: number, b: number){
  return a + b;
}

function List<ItemType>({
  items, 
  render, 
 } : { 
    items: ItemType[]; 
    render: (item: ItemType, index: number) => React.ReactNode;
  }) {
  return (
    <ul>
      {items.map((item, index) => {
        return render(item, index);
      })}
    </ul>
  );
}


type TypographyProps = {
  children: React.ReactNode;
  size?: "small" | "large";
};

type ParagraphProps = {
  color: string;
};

const Paragraph = ({ 
  children, 
  size,
  color,
 }: TypographyProps & ParagraphProps) => {
  return ( 
  <h1 
  style={{
    fontSize: size === "small" ? "1.5rem" : "3rem",
    color: color,
  }}
  >
    {children}
    </h1>
  );
};

const Title = ({ children, size = "small" }: TypographyProps) => {
  return ( 
  <h1 
  style={{
    fontSize: size === "small" ? "1.5rem" : "3rem",
  }}
  >
    {children}
    </h1>
  );
};

function App() {
  const [count, setCount] = useState(0)

  const items = [
    {
      id: 1,
      name: "John Doe",
    },
    {
      id: 2,
      name: "Luana Thurow"
    },
  ]

  return <div className="App">
    <Title size='small'>
      <span>
        Hello! <b> My name is Luana</b>
      </span>
    </Title>

    <Paragraph color='pink' size='small'> 
      I'm Developer</Paragraph>

    <List 
    items={items}
    render={(item, index) => {
      if (item.id === 1) {
      return <p>{item.name}</p>
    }
    return <h3>{item.name}</h3>
    }}
    />
  </div>;
}

export default App
