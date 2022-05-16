import React from 'react';
import { Link } from 'react-router-dom';

const ChoiceStep = ({ activeItem, setActiveItem, items, choiceText, numberStep }) => {
  const getItemClass = (item) => {
    let itemClass = 'button button_option blue';
    if (Array.isArray(activeItem)) {
      if (activeItem.find((i) => i.id == item.id)) itemClass += ' button_option_active';
    } else if (item.id == activeItem.id) itemClass += ' button_option_active';

    return itemClass;
  };

  const getPreviousNextUrl = () => {
    const urls = {
      1: '/first_step',
      2: '/second_step',
      3: '/third_step',
      4: '/fourth_step',
      5: '/gratitude',
    };

    return {
      previousUrl: numberStep > 1 ? urls[numberStep - 1] : '',
      nextUrl: numberStep < 5 ? urls[numberStep + 1] : '',
    };
  };

  const handleClickItem = (item) => {
    if (Array.isArray(activeItem)) {
      if (activeItem.find((i) => i.id == item.id)) {
        setActiveItem(activeItem.filter((currentItem) => currentItem.id != item.id));
      } else {
        setActiveItem([...activeItem, item]);
      }
    } else {
      setActiveItem(item);
    }
  };

  return (
    <main>
      <div className="container">
        <div className="step_choose first_step">
          <div className="choose_category">
            <p className="title">Совсем скоро ты сможешь задать вопрос, но сначала</p>
            <p className="choose_cat">Выбери {choiceText}:</p>
            <ul className="list">
              {items.map((item) => (
                <li
                  key={item.id}
                  className={getItemClass(item)}
                  onClick={() => {
                    handleClickItem(item);
                  }}>
                  {numberStep !== 3
                    ? item.name
                    : `${item.surname} 
                       ${item.firstname && item.firstname[0]}. 
                       ${item.patronymic && item.patronymic[0]}.`}
                </li>
              ))}
            </ul>
            <div className="buttons_next_back">
              {numberStep != 1 && (
                <Link
                  to={getPreviousNextUrl()['previousUrl']}
                  className="button button_next_back yellow">
                  Назад
                </Link>
              )}
              {numberStep != 5 && (
                <Link
                  to={getPreviousNextUrl()['nextUrl']}
                  className="button button_next_back yellow">
                  Далее
                </Link>
              )}
            </div>
          </div>
          <div className="div_img">
            <img src="img/main_img.jpg" alt="main_img" />
          </div>
        </div>
      </div>
    </main>
  );
};

export default ChoiceStep;
