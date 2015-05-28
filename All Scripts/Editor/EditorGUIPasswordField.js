

class EditorGUIPasswordField extends EditorWindow {

    var text : String = "Some text here";

	@MenuItem("Examples/Editor Password field usage")
    static function Init() {
        var window = GetWindow(EditorGUIPasswordField);
        window.Show();
    }

    function OnGUI() {
        text = EditorGUI.PasswordField(
			Rect(3,3,position.width - 6, 20),
			"Type Something:",
			text);
        EditorGUI.LabelField(
			Rect(3,25,position.width - 5, 20),
			"Written Text:",
			text);

    }
}