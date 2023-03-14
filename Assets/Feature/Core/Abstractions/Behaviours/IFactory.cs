using UnityEngine;

namespace SSE.Core.Abstractions.Behaviours
{
    /// <summary>
    /// Интерфейс фабрики
    /// </summary>
    /// <typeparam name="T">Тип объекта которые надо создать</typeparam>
    public interface IFactory<out T>
    {
        /// <summary>
        /// Иницилизация фабрики
        /// </summary>
        public void Init(int amount);
        
        /// <summary>
        /// Создать элемент
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="parent">Ссылка на Tranform родителя</param>
        /// <returns>Созданный объект</returns>
        public T Create(string name, Transform parent = null);
    }
}