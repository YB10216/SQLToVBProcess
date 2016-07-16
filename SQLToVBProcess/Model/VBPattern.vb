Public Module VBPattern
    Public Const SQLEND_PATTERN = "[\s]*[\/]{2}" 'SQL,因為沒辦法,所以改抓行尾,行尾特徵是空白加//
    Public Const PARA_PATTERN = ":[\w]+" '參數,特徵是開頭冒號加英文
    Public Const NOTE_PATTERN = "//[\s\w.\u4e00-\u9fa5]+" '中文註解,特徵是開頭//加中文,空白隔開
    Public Const SINGLE_NOTE_PATTERN = "[\w.\u4e00-\u9fa5]+" '單一中文註解,特徵沒有空白
    Public Const EXCEPT_PATTERN = "^(if|else|end|{|})" '例外
    Public Const INVERSE_SQLBEGIN_PATTERN = "\(""" '反向 
    Public Const INVERSE_SQLEND_PATTERN = """\)" '反向 
    Public Const INVERSE_NOTE_PATTERN = "[)]\s'[\s\w.\u4e00-\u9fa5]" '中文註解,特徵是開頭//加中文,空白隔開
End Module
