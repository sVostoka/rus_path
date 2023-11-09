using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public List<MapPoint> points;
    MapPoint currentPoint;
    List<int> pathHerou = new List<int>();

    Conductor conductor;

    // Start is called before the first frame update
    void Start()
    {
        points  = new List<MapPoint>() 
        {
            new MapPoint(0, TypePoint.startPoint, new List<int>(){1}),
            new MapPoint(1, TypePoint.getCards, new List<int>(){2, 3}),
        
            //Первый путь
            new MapPoint(2, TypePoint.fight, new List<int>(){10}),

            new MapPoint(3, TypePoint.fight, new List<int>(){4, 6}),
            //Второй путь
            new MapPoint(4, TypePoint.getBonuses, new List<int>(){5}),
            new MapPoint(5, TypePoint.fight, new List<int>(){10}),

            //Третий путь
            new MapPoint(6, TypePoint.fight, new List<int>(){7}),
            new MapPoint(7, TypePoint.getBonuses, new List<int>(){8}),
            new MapPoint(8, TypePoint.fight, new List<int>(){9}),
            new MapPoint(9, TypePoint.getCards, new List<int>(){10}),

            new MapPoint(10, TypePoint.endPoint, new List<int> { }),
        };

        (currentPoint, points, pathHerou) = Saver.getStateMap(points);

        conductor = new Conductor();
    }

    void Update()
    {
        setInteractable();
        setColorPoints();
    }

    void setInteractable()
    {
        foreach (var point in points)
        {
            bool marker = false;
            foreach (var childId in currentPoint.children)
            {
                if (childId == point.id)
                {
                    marker = true;
                    break;
                }
            }
            point.button.interactable = marker;
        } 
    }

    void setColorPoints()
    {
        foreach (var index in pathHerou)
        {
            var colorBloc = points[index].button.colors;
            colorBloc.disabledColor = Color.green;
            points[index].button.colors = colorBloc;
        }

        foreach (var point in points)
        {
            if(point.button.interactable == true) 
            {
                var colorBloc = point.button.colors;
                colorBloc.highlightedColor = Color.red;
                point.button.colors = colorBloc;
            }
        }
    }

    public void changePoint(int id)
    {
        foreach (var point in points)
        {
            if (id == point.id)
            {
                pathHerou.Add(points.IndexOf(point));
                currentPoint = point;
                break;
            }
        }

        Saver.saveStateMap(currentPoint, points, pathHerou);

        switch (currentPoint.type)
        {
            case TypePoint.fight:
                conductor.findScene("Fight");
                break;
            case TypePoint.getCards:
                conductor.findScene("GetCards");
                break;
            case TypePoint.getBonuses:
                conductor.findScene("GetBonus");
                break;
            case TypePoint.endPoint:
                conductor.findScene("BossFight");
                break;
        }
    }
}

public class MapPoint
{
    public int id;
    public string name;
    public TypePoint type;
    public List<int> children;
    public Button button;

    public MapPoint(int id = 0, 
        TypePoint type = TypePoint.startPoint,
        List<int> children = null)
    {
        this.id = id;
        this.type = type;
        this.children = children;
        name = id.ToString() + type.ToString();
        button = GameObject.Find(name).GetComponent<Button>();
    }
}

public enum TypePoint
{
    startPoint,
    getCards,
    fight,
    getBonuses,
    endPoint,
}
