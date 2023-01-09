using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResultTicketfix", menuName = "Sphinx/ResultTicketfix")]
public class ResultTicketfix : ScriptableObject
{
    public List<LineFix> correctFixes;
    public List<LineFix> wrongFixes;
    public List<LineFix> repeatFixes;
}
