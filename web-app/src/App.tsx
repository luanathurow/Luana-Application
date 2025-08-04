import './App.css';
import React, { useState } from 'react';
import styled from 'styled-components';

const TitleHeader: React.FC<{ title: string }> = ({ title }) => {
  return (
    <header className="top-title">
      <img src="/rock-icon.png" alt="Ícone" className="icon" />
      <h1>{title}</h1>
    </header>
  );
};

const Paragraph = ({ children, size = "small", color }: any) => {
  return (
    <p
      style={{
        fontSize: size === "small" ? "1.5rem" : "2rem",
        color,
        margin: '20px 0',
      }}
    >
      {children}
    </p>
  );
};

const ButtonSpotify = ({ text, clicked, onClick }: any) => {
  return (
    <button className={`button-spotify ${clicked ? "clicked" : ""}`} onClick={onClick}>
      {text}
    </button>
  );
};

// Centralização geral
const CenteredContainer = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding-top: 120px;
  text-align: center;
  width: 100%;
`;

// Limita a largura do conteúdo para manter centralizado e bonito
const ContentWrapper = styled.div`
  max-width: 800px;
  width: 100%;
  padding: 0 20px;
  text-align: center;
  box-sizing: border-box;
`;

function MyUI() {
  const [clicked, setClicked] = useState(true);
  const handleClick = () => setClicked(prev => !prev);

  return (
  <>
    <TitleHeader title="Luana Thurow" />

    <CenteredContainer>
      <ContentWrapper>
        <Paragraph color="#ff69b4" size="large">
          Welcome to the Rock Princess Page
        </Paragraph>

        <img src="/avril-lavigne.jpg" alt="Avril Lavigne" className="main-image" />

        <Paragraph color="white" size="small">
          A tribute to style, music, and attitude. Here you'll find playlists, vibes and aesthetic that scream Avril!
        </Paragraph>

        <ButtonSpotify
          clicked={clicked}
          onClick={handleClick}
          text={clicked ? "🎧 Acesse o Spotify" : "🎶 Redirecionando..."}
        />
      </ContentWrapper>
    </CenteredContainer>

    <footer className="footer">
      <p>Made by Luana Thurow 💖</p>
    </footer>
  </>
);

}

export default MyUI;
